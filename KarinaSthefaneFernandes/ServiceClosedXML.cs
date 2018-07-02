using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinaSthefaneFernandes
{
    public class ServiceClosedXML
    {
        public static void CriarPlanilhaSapatos(IEnumerable<Sapato> sapatos, String caminho)
        {
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            //foreach (Sapato S in sapatos)
            //{
                //Um arquivo excel pode conter várias planilhas. 
                var worksheet = workbook.Worksheets.Add("Estoque");
                worksheet.Cell("A1").Value = "Estoque Sapato";
                var columnNome = worksheet.Column("A");
                var columnCadarco = worksheet.Column("B");
                var columnMaterial = worksheet.Column("C");
                var columnCor= worksheet.Column("D");
                var columnPreco = worksheet.Column("E");
                var columnTamanho = worksheet.Column("F");
                var columnQuantidade = worksheet.Column("G");
                int ListaSapatosLinhaInicio = 2;
                columnNome.Cell(ListaSapatosLinhaInicio).
                    Value = "Nome";
                columnCadarco.Cell(ListaSapatosLinhaInicio).
                    Value = "Cadarço";
                columnMaterial.Cell(ListaSapatosLinhaInicio).
                    Value = "Material";
                columnCor.Cell(ListaSapatosLinhaInicio).
                    Value = "Cor";
                columnPreco.Cell(ListaSapatosLinhaInicio).
                    Value = "Preço";
                columnTamanho.Cell(ListaSapatosLinhaInicio).
                    Value = "Tamanho";
                columnQuantidade.Cell(ListaSapatosLinhaInicio).
                    Value = "Quantidade";
                worksheet.Row(ListaSapatosLinhaInicio).Style.Fill.BackgroundColor = XLColor.Blue;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Font.Bold = true;
                ListaSapatosLinhaInicio++;
                foreach (Sapato s in sapatos)
                {
                
                    columnNome.Cell(ListaSapatosLinhaInicio).Value = s.Nome;
                    columnCadarco.Cell(ListaSapatosLinhaInicio).Value = s.Cadarco;
                    columnMaterial.Cell(ListaSapatosLinhaInicio).Value = s.Material;
                    columnCor.Cell(ListaSapatosLinhaInicio).Value = s.Cor;
                    columnPreco.Cell(ListaSapatosLinhaInicio).Value = s.Preco;
                    columnTamanho.Cell(ListaSapatosLinhaInicio).Value = s.Tamanho;
                    columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = s.Quantidade;

                    ListaSapatosLinhaInicio++;
                }
            //}
            //Excel pode utilizar a referência A1 [A1,B2...] ou R1C1
            //Se quiser ler mais sobre acesse o link: https://www.reddit.com/r/excel/comments/6tpgk3/reference_style_r1c1_vs_a1/
            workbook.ReferenceStyle = XLReferenceStyle.A1;
            //Calcular automaticamente os valores das fórmulas.
            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;
            //Persistir o arquivo.
            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }

        public void CriarPlanilhaJogadoresTimes(List<Sapato> list, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
