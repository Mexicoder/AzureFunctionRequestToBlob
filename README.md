﻿# AzureFunctionRequestToBlob
## What is this? 
A Simple HTTP Trigger Azure Function that will take the request body and upload it to Blob Storage. The blob will be names with a new GUID. 

## Purpose
This azure funciton is used to test that HTTP requests are accepted and finishing successfully. 
The Fucntion Exectuion is verified by looking into it's accosiated Storage Account (usually the destination is defined with in the AzureWebJobsStorage Environmental Variable)

## Why did i make this?
I created this when trying to validate that my Azure Monitoring Alert [Webhooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/action-groups#webhook) and [Secure Webhooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/action-groups#secure-webhook) were working properly.
