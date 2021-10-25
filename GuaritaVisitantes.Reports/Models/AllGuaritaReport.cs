using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Reports.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Reflection;

namespace GuaritaVisitantes.Reports.Models
{
    public class AllGuaritaReport : IAllGuaritaReport
    {
        private readonly IEntradasSaidasRepository _EntradasSaidasRepository;
        private MemoryStream _Stream;
        private Document _Doc;

        public AllGuaritaReport(IEntradasSaidasRepository entradasSaidasRepository)
        {
            _EntradasSaidasRepository = entradasSaidasRepository;
            _Stream = new MemoryStream();
            _Doc = new Document();
        }


        public void Dispose()
        {
            _Stream.Close();
        }

        public void Gerar(DateTime dateIni, DateTime dateEnd)
        {
            //Configurando o documento
            _Doc.SetPageSize(PageSize.A4.Rotate());
            _Doc.SetMargins(10, 10, 10, 10);
            _Doc.AddCreationDate();
            _Doc.AddAuthor("Tradição Alimentos");
            _Doc.AddLanguage("Portuguese");

            PdfWriter writer = PdfWriter.GetInstance(_Doc, _Stream);
            _Doc.Open();

            //Fontes
            Font titleFont = new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.BOLD);
            Font subTitleFont = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.BOLD);
            Font normalFont = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);

            string imgPath = Path.Combine((new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath.Split(new string[] { "/bin" }, StringSplitOptions.None)[0], "Content", "img", "logotradicao.png");
            Image imgLogo = Image.GetInstance(imgPath);
            imgLogo.ScaleToFit(65f, 65f);
            imgLogo.SetAbsolutePosition(((PageSize.A4.Rotate().Width - imgLogo.ScaledWidth) / 2), ((PageSize.A4.Rotate().Height - imgLogo.ScaledHeight) - 30));
            _Doc.Add(imgLogo);

            _Doc.Add(new Paragraph(" "));
            _Doc.Add(new Paragraph(" "));
            _Doc.Add(new Paragraph(" "));
            _Doc.Add(new Paragraph(" "));

            Paragraph titulo = new Paragraph("TODOS", titleFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            _Doc.Add(titulo);

            _Doc.Add(new Paragraph(" "));

            Paragraph subTitulo = new Paragraph("", subTitleFont);
            subTitulo.Alignment = Element.ALIGN_CENTER;
            subTitulo.Add(dateIni.ToShortDateString() + " à " + dateEnd.ToShortDateString());
            _Doc.Add(subTitulo);

            _Doc.Add(new Paragraph(" "));
            _Doc.Add(new Paragraph(" "));

            float[] relativeWidths = { 0.20f, 0.28f, 0.27f, 0.125f, 0.125f };
            PdfPTable tabela = new PdfPTable(relativeWidths);
            tabela.WidthPercentage = 100;
            tabela.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell titVeiculo = new PdfPCell(new Phrase("Veiculo", subTitleFont));
            tabela.AddCell(titVeiculo);

            PdfPCell titVisitante = new PdfPCell(new Phrase("Visitante", subTitleFont));
            tabela.AddCell(titVisitante);

            PdfPCell titObs = new PdfPCell(new Phrase("Observações", subTitleFont));
            tabela.AddCell(titObs);

            PdfPCell titEntradaHr = new PdfPCell(new Phrase("Data Entrada", subTitleFont));
            tabela.AddCell(titEntradaHr);

            PdfPCell titSaidaHr = new PdfPCell(new Phrase("Data Saída", subTitleFont));
            tabela.AddCell(titSaidaHr);        

            foreach (var item in _EntradasSaidasRepository.GetSaidas(dateIni, dateEnd))
            {
                var entrada = _EntradasSaidasRepository.FindById((int)item.EntradaId);
                string dataEntrada = "";

                if (entrada != null)
                {
                    dataEntrada = entrada.Data.ToString("dd/MM/yyyy HH:mm");       
                }

                string veiculo = item.VeiculoVisitante != null ? item.VeiculoVisitante.Placa + " - " + item.VeiculoVisitante.Descricao : "Sem Veiculo";

                PdfPCell cellVeiculo = new PdfPCell(new Phrase(veiculo, normalFont));
                tabela.AddCell(cellVeiculo);

                PdfPCell cellVisitante = new PdfPCell(new Phrase(item.Visitante.Nome, normalFont));
                tabela.AddCell(cellVisitante);

                PdfPCell cellObs = new PdfPCell(new Phrase(item.Observacoes, normalFont));
                tabela.AddCell(cellObs);

                PdfPCell cellEntradaHr = new PdfPCell(new Phrase(dataEntrada, normalFont));
                tabela.AddCell(cellEntradaHr);

                PdfPCell cellSaidaHr = new PdfPCell(new Phrase(item.Data.ToString("dd/MM/yyyy HH:mm"), normalFont));
                tabela.AddCell(cellSaidaHr);
            }

            _Doc.Add(tabela);

            _Doc.Close();
        }

        public MemoryStream GetReport()
        {
            return _Stream;
        }
    }
}
