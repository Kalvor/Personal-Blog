terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>3.0"
    }
  }
  backend "azurerm" {
    resource_group_name  = "RG-Development"
    storage_account_name = "tfstatesstorage0001"
    container_name       = "personalblog"
    key                  = "personalblog.tfstate"
  }
}

provider "azurerm" {
  client_id       = var.AZURE_CLIENT_ID
  client_secret   = var.ARM_CLIENT_SECRET
  tenant_id       = var.AZURE_TENANT_ID
  subscription_id = var.AZURE_SUBSCRIPTION_ID
  features {}
}
