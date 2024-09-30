// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System.Runtime.CompilerServices;
using System.Text;

//var question = new MLModel1.ModelInput()
//{
//    Col0 = "What a wonderful world!"
//};

//var answer = MLModel1.Predict(question);

//var score = answer.Score;
//Console.WriteLine($"");

//return;

Console.WriteLine("Hello, World!");

var filePath = "C:\\Users\\HRESTRE\\Downloads\\90049_OTECEL_S.A._G_16092024.txt";
var lines = File.ReadLinesAsync(filePath, Encoding.Latin1).ToBlockingEnumerable();

//foreach (var line in lines)
//{
//    Console.WriteLine(line);

//}


using (PdfWriter writer = new PdfWriter("C:\\Users\\HRESTRE\\Downloads\\90049_OTECEL_S.A._G_16092024.pdf"))
{
    // Initialize PDF document
    PdfDocument pdfDoc = new PdfDocument(writer);

    // Set the page size to A4 and landscape    
    pdfDoc.SetDefaultPageSize(PageSize.A4.Rotate());

    // Initialize document
    using (Document document = new Document(pdfDoc))
    {
        document.SetTextAlignment(TextAlignment.JUSTIFIED_ALL);

        var flagDetail = false;
        var flagFooter = false;
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            var text = line.Replace(" ", "\u00A0");

            //var p = new Paragraph(text);

            //Text text = new Text("");
            //text.SetNextRenderer(new CodeRenderer(text));

            //var p = new Paragraph(text);
            var p = new Paragraph($"{char.MinValue}{line}");
            //p.SetWordSpacing(2.5f);
            p.SetFontSize(10);
            //p.SetTextAlignment(TextAlignment.JUSTIFIED_ALL));

            if (line.Contains(':'))
            {
                //p.SetWordSpacing(1f);
                p.SetTextAlignment(TextAlignment.CENTER);
            }

            //if (line.Contains("______")) { flagDetail = true; }

            //if (flagDetail)
            //{
            //    p.SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
            //}

            //if (line.Contains("Comisiones"))
            //{
            //    flagDetail = false;
            //    flagFooter = true;
            //}

            //if (flagFooter)
            //{
            //    p.SetTextAlignment(TextAlignment.RIGHT);
            //}

            document.Add(p);
        }

        // Close the document
        document.Close();
    }

    Console.WriteLine("PDF created successfully!");
}


public class CodeRenderer : TextRenderer
{
    public CodeRenderer(Text textElement) : base(textElement)
    {
    }

    public override IRenderer GetNextRenderer()
    {
        return new CodeRenderer((Text)modelElement);
    }

    public override void TrimFirst()
    {
    }
}