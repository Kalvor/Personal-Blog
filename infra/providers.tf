terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>3.0"
    }
  }
  backend "azurerm" {
    client_id            = var.ARM_CLIENT_ID
    client_secret        = var.ARM_CLIENT_SECRET
    tenant_id            = var.ARM_TENANT_ID
    subscription_id      = var.ARM_SUBSCRIPTION_ID
    resource_group_name  = "RG-Development"
    storage_account_name = "tfstatesstorage0001"
    container_name       = "personalblog"
    key                  = "personalblog.tfstate"
  }
}

provider "azurerm" {
  use_msi         = true
  client_id       = var.ARM_CLIENT_ID
  client_secret   = var.ARM_CLIENT_SECRET
  tenant_id       = var.ARM_TENANT_ID
  subscription_id = var.ARM_SUBSCRIPTION_ID
  features {}
}
