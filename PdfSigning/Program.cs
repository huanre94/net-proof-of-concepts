using iText;
using iText.Kernel.Pdf;
using iText.Signatures;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


PdfSigner pdfSigner = new PdfSigner(new PdfReader(""),
                                    new FileStream("", FileMode.Create),
                                    new StampingProperties());
SignerProperties signerProperties = new SignerProperties();
signerProperties.SetCertificationLevel(PdfSigner.CERTIFIED_NO_CHANGES_ALLOWED);

signerProperties.SetFieldName("signature");