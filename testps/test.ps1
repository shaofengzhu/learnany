function Get-AccessToken {
    $response = Invoke-WebRequest -Uri 'http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https%3A%2F%2Fdatabase.windows.net%2F' `
                -Headers @{Metadata="true"}
    $content =$response.Content | ConvertFrom-Json
    $access_token = $content.access_token
    Write-Host "The managed identities for Azure resources access token is $access_token"
    return $access_token
}

Get-AccessToken

