using PostmanCloneLibrary;

namespace PostmanCloneUI;

public partial class Dashboard : Form
{
    private readonly IApiAccess api = new ApiAccess();

    public Dashboard()
    {
        InitializeComponent();
        cbHttpVerbSelection.SelectedIndex= 0;
    }

    private async void btnCallApi_Click(object sender, EventArgs e)
    {
        systemStaus.Text = "Calling API...";
        txtResults.Text = "";

        // Validate URL
        if (!api.IsValidUrl(txtApi.Text))
        {
            systemStaus.Text = "Invalid URL";
            return;
        }

        // Validate HTTP Verb
        HttpAction action;
        if (Enum.TryParse(cbHttpVerbSelection.SelectedItem!.ToString(), out action) == false)
        {
            systemStaus.Text = "Invalid HTTP Verb";
            return;
        }


        try
        {
            txtResults.Text = await api.CallApiAsync(txtApi.Text, txtBody.Text, action);
            tcCallData.SelectedTab = resultsTab;
            resultsTab.Focus();

            systemStaus.Text = "Ready";
        }
        catch (Exception ex)
        {
            txtResults.Text = "Error: " + ex.Message;
            systemStaus.Text = "Error";
        }
    }
}
