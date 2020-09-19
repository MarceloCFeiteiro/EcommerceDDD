using Entities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Web_ECommerce.Models
{
    public class HelperQrCode : Controller
    {
        public async Task<IActionResult> Download(CompraUsuario compraUsuario, IWebHostEnvironment webHostEnvironment)
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                #region Configurações da Folha

                var page = doc.AddPage();

                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = XGraphics.FromPdfPage(page);
                var corFonte = XBrushes.Black;

                #endregion Configurações da Folha

                #region Numeração das Páginas

                int qtdPaginas = doc.PageCount;

                var numeracaoPaginas = new XTextFormatter(graphics);
                numeracaoPaginas.DrawString(Convert.ToString(qtdPaginas), new XFont("Arial", 10), corFonte, new XRect(575, 825, page.Width, page.Height));

                #endregion Numeração das Páginas

                #region Logo

                var webRoot = webHostEnvironment.WebRootPath;

                var logoFatura = string.Concat(webRoot, "/img/", "loja-virtual-1.png");

                var imagem = XImage.FromFile(logoFatura);

                graphics.DrawImage(imagem, 20, 5, 300, 50);

                #endregion Logo

                #region Informações 1

                var relatorioCobranca = new XTextFormatter(graphics);
                var titulo = new XFont("Arial", 14, XFontStyle.Bold);
                relatorioCobranca.Alignment = XParagraphAlignment.Center;
                relatorioCobranca.DrawString("BOLETO ONLINE", titulo, corFonte, new XRect(0, 65, page.Width, page.Height));

                #endregion Informações 1

                #region Informações 2

                var alturaTituloDetalhesY = 120;
                var detalhes = new XTextFormatter(graphics);
                var tituloInfo_1 = new XFont("Arial", 8, XFontStyle.Regular);

                detalhes.DrawString("Dados do Banco:", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Banco Itau 004:", tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Código gerado", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("000000 000000 000000 000000", tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Quantidade:", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.QuantidadeProdutos.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Valor Total:", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.ValorTotal.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                var tituloInfo_2 = new XFont("Arial", 8, XFontStyle.Bold);

                try
                {
                    var img = await GeraQrCode("Dados do Banco aqui");

                    var streamImage = new MemoryStream(img);

                    var qrCode = XImage.FromStream(() => streamImage);

                    alturaTituloDetalhesY += 40;

                    graphics.DrawImage(qrCode, 140, alturaTituloDetalhesY, 310, 310);
                }
                catch (Exception erro)
                {
                    throw;
                }

                alturaTituloDetalhesY += 620;
                detalhes.DrawString("Canhoto com QrCOde para pagamento online.", tituloInfo_2, corFonte, new XRect(20, alturaTituloDetalhesY, page.Width, page.Height));

                #endregion Informações 2

                using (var stream = new MemoryStream())
                {
                    var contentType = "application/pdf";
                    doc.Save(stream, false);
                    return File(stream.ToArray(), contentType, "BoletoLojaOnline.pdf");
                }
            }
        }

        private async Task<byte[]> GeraQrCode(string dadosBanco)
        {
            QRCodeGenerator qrCodeGenarator = new QRCodeGenerator();

            var qrCodeData = qrCodeGenarator.CreateQrCode(dadosBanco, QRCodeGenerator.ECCLevel.H);

            var qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var bitmapBytes = BitmapToBytes(qrCodeImage);

            return bitmapBytes;
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}