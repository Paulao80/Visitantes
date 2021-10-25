using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Reports.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Reports.Models
{
    public class AllTransporteReport : IAllTransporteReport
    {
        private readonly ISaidasEntradasRepository _SaidasEntradasRepository;
        private MemoryStream _Stream;
        private Document _Doc;

        public AllTransporteReport(ISaidasEntradasRepository saidasEntradasRepository)
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

            float[] relativeWidths = {  0.17f, 0.14f, 0.14f, 0.18f, 0.125f, 0.125f, 0.06f, 0.06f };
            PdfPTable tabela = new PdfPTable(relativeWidths);
            tabela.WidthPercentage = 100;
            tabela.HorizontalAlignment = Element.ALIGN_CENTER;  

            PdfPCell titVeiculo = new PdfPCell(new Phrase("Veiculo", subTitleFont));
            tabela.AddCell(titVeiculo);

            PdfPCell titMotoristaS = new PdfPCell(new Phrase("Motorista S.", subTitleFont));
            tabela.AddCell(titMotoristaS);

            PdfPCell titMotoristaE = new PdfPCell(new Phrase("Motorista E.", subTitleFont));
            tabela.AddCell(titMotoristaE);

            PdfPCell titObs = new PdfPCell(new Phrase("Observações", subTitleFont));
            tabela.AddCell(titObs);

            PdfPCell titSaidaHr = new PdfPCell(new Phrase("Data Saída", subTitleFont));
            tabela.AddCell(titSaidaHr);

            PdfPCell titEntradaHr = new PdfPCell(new Phrase("Data Entrada", subTitleFont));
            tabela.AddCell(titEntradaHr);

            PdfPCell titSaidaKm = new PdfPCell(new Phrase("KM S.", subTitleFont));
            tabela.AddCell(titSaidaKm);

            PdfPCell titEntradaKm = new PdfPCell(new Phrase("KM E.", subTitleFont));
            tabela.AddCell(titEntradaKm);

            foreach (var item in _SaidasEntradasRepository.GetEntradas(dateIni, dateEnd))
            {
                var saida = _SaidasEntradasRepository.FindById((int)item.SaidaId);
                string dataSaida = "", kmSaida = "", MotoristaS = "";

                if (saida != null)
                {
                    dataSaida = saida.Data.ToString("dd/MM/yyyy HH:mm");
                    kmSaida = saida.KM.ToString();
                    MotoristaS = saida.Motorista.Nome;
                }

                string veiculo = item.Veiculo.Placa + " - " + item.Veiculo.Descricao;

                PdfPCell cellVeiculo = new PdfPCell(new Phrase(veiculo, normalFont));
                tabela.AddCell(cellVeiculo);

                PdfPCell cellMotoristaS = new PdfPCell(new Phrase(MotoristaS, normalFont));
                tabela.AddCell(cellMotoristaS);

                PdfPCell cellMotoristaE = new PdfPCell(new Phrase(item.Motorista.Nome, normalFont));
                tabela.AddCell(cellMotoristaE);

                PdfPCell cellObs = new PdfPCell(new Phrase(item.Observacoes, normalFont));
                tabela.AddCell(cellObs);  

                PdfPCell cellSaidaHr = new PdfPCell(new Phrase(dataSaida, normalFont));
                tabela.AddCell(cellSaidaHr);

                PdfPCell cellEntradaHr = new PdfPCell(new Phrase(item.Data.ToString("dd/MM/yyyy HH:mm"), normalFont));
                tabela.AddCell(cellEntradaHr);

                PdfPCell cellSaidaKm = new PdfPCell(new Phrase(kmSaida, normalFont));
                tabela.AddCell(cellSaidaKm);

                PdfPCell cellEntradaKm = new PdfPCell(new Phrase(item.KM.ToString(), normalFont));
                tabela.AddCell(cellEntradaKm);
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
