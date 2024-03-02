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
  use_oidc = true
  features {}
}
