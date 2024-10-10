using PostmanCloneLibrary;
using System.Text.Json;

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
        txtHeaders.Text = "";

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

        // Process headers
        Dictionary<string, string>? headers = null;
        try
        {
            if (!string.IsNullOrWhiteSpace(txtHeaders.Text))
            {
                headers = JsonSerializer.Deserialize<Dictionary<string, string>>(txtBody.Text);
            }
        }
        catch (Exception ex)
        {
            systemStaus.Text = "Invalid Headers";
            return;
        }

        //
        try
        {
            ApiResponse response = await api.CallApiAsync(txtApi.Text, txtBody.Text, action, headers);

            txtResults.Text = response.Body;

            // Convert headers to JSON
            var headersJson = JsonSerializer.Serialize(response.Headers, new JsonSerializerOptions { WriteIndented = true });
            txtHeaders.Text = headersJson;

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
