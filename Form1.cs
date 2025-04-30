using QuestPDF.Fluent;
using QuestPDF.Infrastructure;


namespace pisa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var reporte = ReporteDataSource.ObtenerReporte();
            var documento = new ReporteDocumento(reporte);
            try
            {
                documento.GeneratePdfAndShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var invoice = InvoiceDocumentDataSource.GetInvoiceDetails(); 
            var documento = new InvoiceDocument(invoice);

            documento.GeneratePdfAndShow();
        }
    }
}
