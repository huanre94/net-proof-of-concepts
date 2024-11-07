int totalParticipants = 10;
var (gameResults, allParticipants) = CoinTossGame.PlayGame(totalParticipants);

Console.WriteLine("Resultados de cada ronda:");
foreach (var result in gameResults)
{
    Console.WriteLine($"Ronda {result.RoundNumber}: Quedan {result.ParticipantsRemaining} participantes, {result.ParticipantsEliminated} eliminados");
}

Console.WriteLine("\nHistorial de lanzamientos de todos los participantes:");
foreach (var participant in allParticipants)
{
    Console.WriteLine($"\nParticipante {participant.Id}:");
    Console.WriteLine($"Historial de lanzamientos: {string.Join(", ", participant.CoinTossHistory)}");
}

public class CoinTossGame
{
    public class Participant
    {
        public int Id { get; set; }
        public List<string> CoinTossHistory { get; set; } = new List<string>();
    }

    public class IterationResult
    {
        public int RoundNumber { get; set; }
        public int ParticipantsRemaining { get; set; }
        public int ParticipantsEliminated { get; set; }
    }

    public static (List<IterationResult> GameResults, List<Participant> AllParticipants) PlayGame(int totalParticipants)
    {
        var results = new List<IterationResult>();
        var random = new Random();
        int roundNumber = 0;

        // Inicializa la lista de participantes con sus identificadores
        List<Participant> allParticipants = Enumerable.Range(1, totalParticipants)
                                                      .Select(id => new Participant { Id = id })
                                                      .ToList();

        // Lista de participantes activos en la ronda actual
        List<Participant> activeParticipants = new List<Participant>(allParticipants);

        // Comienza el proceso de rondas
        while (activeParticipants.Count > 1)
        {
            roundNumber++;
            List<Participant> survivingParticipants = new List<Participant>();

            foreach (var participant in activeParticipants)
            {
                // Lanzamiento de la moneda: 0 = Cruz (eliminado), 1 = Cara (sigue)
                bool isHeads = random.Next(0, 2) == 1;

                // Guarda el resultado del lanzamiento en el historial del participante
                participant.CoinTossHistory.Add(isHeads ? "Cara" : "Cruz");

                if (isHeads)
                {
                    survivingParticipants.Add(participant);
                }
            }

            int eliminatedCount = activeParticipants.Count - survivingParticipants.Count;

            // Almacena el resultado de la ronda
            results.Add(new IterationResult
            {
                RoundNumber = roundNumber,
                ParticipantsRemaining = survivingParticipants.Count,
                ParticipantsEliminated = eliminatedCount
            });

            // Actualiza la lista de participantes activos para la próxima ronda
            activeParticipants = survivingParticipants;
        }

        return (results, allParticipants);
    }
}


