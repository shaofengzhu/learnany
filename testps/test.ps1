param (
    [switch]$AciRegistry
)

$url = 'http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https%3A%2F%2Fdatabase.windows.net%2F'
if ($AciRegistry.IsPresent) {
    $url = 'http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https%3A%2F%2Fcontainerregistry.azure.net%2F'
}

function Get-AccessToken {
    try {
        $response = Invoke-WebRequest -Uri $url `
            -Headers @{Metadata="true"} `

        Write-Host $response.Content
        $content =$response.Content | ConvertFrom-Json
        $access_token = $content.access_token
        Write-Host "The managed identities for Azure resources access token is $access_token"
        return $access_token
    }
    catch {
        $responseBody = $_.Exception.Response.Content.ReadAsStringAsync().Wait()
        Write-Host $responseBody
        return $responseBody
    }
}

Get-AccessToken

