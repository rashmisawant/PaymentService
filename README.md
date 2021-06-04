# Introduction 
Payment Service which returns Payment Details and Account Balance for the specified account
E.g.
https://localhost:44392/api/Account/45678/balance
https://localhost:44392/api/Account/45678/payments


# Getting Started
Following Projects are included in the Solution
1.Payment.Service - ASP.Net core API which returns Account Balance and Payments
2.Payment.Model - Models which will be returned by API 
3.Payment.BL - Business Layer to return Account Balance and Payments
4.Payment.Dal - Data Access Layer to return entities from in-memory service
5.Payment.BL.Test - Unit test project to test business layer
6.Payment.Client - RestClient Wrapper which can be called from UI layer

# Publish
We can publish it Azure using msbuild.exe by creating publish profile  
Following command can be configured in teamcity using command line option

"..\msbuild.exe" 
"PaymentService.sln" "-t:clean;rebuild;publish" "/p:DeployOnBuild=true" "/p:PublishProfile=%AzurePublishProfile%" 
"/p:Username=%AzurePublishUserName%;Password=%AzurePublishPassword%" /p:Configuration=Release
 