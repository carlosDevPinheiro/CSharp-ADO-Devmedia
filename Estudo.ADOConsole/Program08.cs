using Estudo.ADOConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Estudo.ADOConsole
{
    public class Program08
    {
        static void Main(string[] args)
        {

            
            StreamReader leitor = File.OpenText(@"C:\Users\proga\Downloads\NomesJson.txt");
            List<string> nomes = new List<string>();


            var nomeArray = leitor.ReadToEnd().Split(',');
            string nome = string.Empty;
            string sobreNome = string.Empty;

            foreach (string palavra in nomeArray)
            {
                foreach (char ch in palavra)
                {
                    if (char.IsLetter(ch))
                    {
                        nome += ch;
                        

                    } else if (char.IsWhiteSpace(ch))
                    {
                        nomes.Add(nome + ",");
                    }
                }

               
            }

            nomes.ForEach(x => Console.WriteLine(x));

            


          //  FileStream criador = File.Create($@"C:\Users\proga\Downloads\NomesJson{DateTime.Now.Year}.txt");
           
            


          //  //Byte[] arquivo = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(nomes));

          ////  criador.Write(arquivo);
          //  criador.Close();

          //  StreamReader leitor2 = File.OpenText($@"C:\Users\proga\Downloads\NomesJson{DateTime.Now.Year}.txt");
          //  var ListaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(leitor2.ReadToEnd());

          //  foreach (Pessoa pessoa in ListaPessoas)
          //  {
          //      Console.WriteLine(pessoa.ToString());
          //  }
        }
    }
}




// Trabalhando com word

/*
sing Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Text;

namespace FormularioPerguntas
{
    public class ProgramIO
    {

		static void  Main(string[] args)
        {
            ObterDados();
        }

        private static void ObterDados()
        {
            
            var NomeArquivo = "Teste.txt";

            DirectoryInfo Diretorio = new DirectoryInfo(@"C:\Users\antonio.pinheiro\Documents\Teste");

            // http://www.andrealveslima.com.br/blog/index.php/2016/06/29/gerando-arquivos-do-word-com-c-e-vb-net/

            //var wordApp = new Application();
            //wordApp.Visible = false;
            //var wordDoc = wordApp.Documents.Add();

            //// Primeiro parágrafo (texto centralizado)
            //var paragrafo1 = wordDoc.Content.Paragraphs.Add();
            //paragrafo1.Range.Text = "Texto centralizado";
            //paragrafo1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //paragrafo1.Range.InsertParagraphAfter();

            //// Segundo parágrafo (formatação diferente)
            //var paragrafo2 = wordDoc.Paragraphs.Add();
            //paragrafo2.Range.Text = "Fonte Arial Negrito, Itálico, Sublinhado, Tamanho 18";
            //paragrafo2.Range.Font.Name = "Arial";
            //paragrafo2.Range.Font.Bold = 1;
            //paragrafo2.Range.Font.Italic = 1;
            //paragrafo2.Range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            //paragrafo2.Range.Font.Size = 18;
            //paragrafo2.Range.InsertParagraphAfter();

            //// Terceiro parágrafo (multiplas formatações)
            //var paragrafo3 = wordDoc.Paragraphs.Add();
            //paragrafo3.Range.Text = "Um pedaço da frase normal, outro pedaço negrito, outro sublinhado";
            //paragrafo3.Range.Select();
            //wordApp.Selection.ClearFormatting();
            //wordApp.Selection.Collapse();
            //var rangeNegrito = wordDoc.Range(paragrafo3.Range.Start + 27, paragrafo3.Range.Start + 47);
            //rangeNegrito.Bold = 1;
            //var rangeSublinhado = wordDoc.Range(paragrafo3.Range.Start + 49);
            //rangeSublinhado.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            //paragrafo3.Range.InsertParagraphAfter();

            //// Quarto parágrafo (tabela)
            //var paragrafo4 = wordDoc.Paragraphs.Add();
            //var tabela = wordDoc.Tables.Add(paragrafo4.Range, 2, 2);
            //tabela.Rows[1].Cells[1].Range.Text = "Col1";
            //tabela.Rows[1].Cells[2].Range.Text = "Col2";
            //tabela.Rows[2].Cells[1].Range.Text = "A";
            //tabela.Rows[2].Cells[2].Range.Text = "B";
            //tabela.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            //tabela.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            //tabela.Select();
            //wordApp.Selection.ClearFormatting();
            //wordApp.Selection.Collapse();
            //paragrafo4.Range.InsertParagraphAfter();

            //// Quinto parágrafo (imagem)
            //var paragrafo5 = wordDoc.Paragraphs.Add();
            //paragrafo5.Range.InlineShapes.AddPicture(Path.Combine(Diretorio.FullName, "penguins.jpg"));

            //wordDoc.SaveAs2(System.IO.Path.Combine(Diretorio.FullName, "documentoAutomation.docx"));
            //wordApp.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            //wordApp.Quit();

            ////FileStream criador = File.Create(Path.Combine(Diretorio.FullName, NomeArquivo));            
            ////byte[] fluxo = new UTF8Encoding(true).GetBytes("Antonio Carlos Pinheiro");
            ////criador.Write(fluxo, 0, fluxo.Length);
            ////criador.Close();

            StreamReader leitor = File.OpenText(Path.Combine(Diretorio.FullName, "documentoAutomation.docx"));

            while(leitor.Read() > 0)
            {
                Console.WriteLine(leitor.ReadToEnd());
            }

            leitor.Close();

            Console.ReadKey();

        }
    }
}
/*
