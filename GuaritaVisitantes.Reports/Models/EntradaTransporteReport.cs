using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Reports.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Reflection;

namespace GuaritaVisitantes.Reports.Models
{
    public class EntradaTransporteReport : IEntradaTransporteReport
    {
        private readonly ISaidasEntradasRepository _SaidasEntradasRepository;
        private MemoryStream _Stream;
        private Document _Doc;

        public EntradaTransporteReport(ISaidasEntradasRepository saidasEntradasRepository)
        {
            _SaidasEntradasRepository = saidasEntradasRepository;
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

            Paragraph titulo = new Paragraph("ENTRADAS", titleFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            _Doc.Add(titulo);

            _Doc.Add(new Paragraph(" "));

            Paragraph subTitulo = new Paragraph("", subTitleFont);
            subTitulo.Alignment = Element.ALIGN_CENTER;
            subTitulo.Add(dateIni.ToShortDateString() + " à " + dateEnd.ToShortDateString());
            _Doc.Add(subTitulo);

            _Doc.Add(new Paragraph(" "));
            _Doc.Add(new Paragraph(" "));

            float[] relativeWidths = { 0.08f, 0.08f, 0.22f, 0.24f, 0.38f };
            PdfPTable tabela = new PdfPTable(relativeWidths);
            tabela.WidthPercentage = 100;
            tabela.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell titData = new PdfPCell(new Phrase("Data", subTitleFont));
            tabela.AddCell(titData);

            PdfPCell titHora = new PdfPCell(new Phrase("Hora", subTitleFont));
            tabela.AddCell(titHora);

            PdfPCell titVeiculo = new PdfPCell(new Phrase("Veiculo", subTitleFont));
            tabela.AddCell(titVeiculo);

            PdfPCell titMotorista = new PdfPCell(new Phrase("Motorista", subTitleFont));
            tabela.AddCell(titMotorista);

            PdfPCell titObs = new PdfPCell(new Phrase("Observações", subTitleFont));
            tabela.AddCell(titObs);

            foreach (var item in _SaidasEntradasRepository.GetEntradas(dateIni, dateEnd))
            {
                PdfPCell cellData = new PdfPCell(new Phrase(item.Data.ToShortDateString(), normalFont));
                tabela.AddCell(cellData);

                PdfPCell cellHora = new PdfPCell(new Phrase(item.Data.ToShortTimeString(), normalFont));
                tabela.AddCell(cellHora);

                string veiculo = item.Veiculo.Placa + " - " + item.Veiculo.Descricao;

                PdfPCell cellVeiculo = new PdfPCell(new Phrase(veiculo, normalFont));
                tabela.AddCell(cellVeiculo);

                PdfPCell cellMotorista = new PdfPCell(new Phrase(item.Motorista.Nome, normalFont));
                tabela.AddCell(cellMotorista);

                PdfPCell cellObs = new PdfPCell(new Phrase(item.Observacoes, normalFont));
                tabela.AddCell(cellObs);
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
