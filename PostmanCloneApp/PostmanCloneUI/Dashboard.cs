using PostmanCloneLibrary;

namespace PostmanCloneUI;

public partial class Dashboard : Form
{
    private readonly IApiAccess api = new ApiAccess();

    public Dashboard()
    {
        InitializeComponent();
    }

    private async void btnCallApi_Click(object sender, EventArgs e)
    {
        systemStaus.Text = "Calling API...";
        txtResults.Text = "";


        // validate api url
        if (!api.IsValidUrl(txtApi.Text))
        {
            systemStaus.Text = "Invalid URL";
            return;
        }



        try
        {
            systemStaus.Text = "Calling API...";

            txtResults.Text = await api.CallApiAsync(txtApi.Text);

            systemStaus.Text = "Ready";
        }
        catch (Exception ex)
        {
            txtResults.Text = "Error: " + ex.Message;
            systemStaus.Text = "Error";
        }
    }
}
