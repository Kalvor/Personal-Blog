terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>3.0"
    }
  }
  backend "azurerm" {
    subscription_id      = "7d62b4e4-e187-41ba-a266-036a7164f434"
    resource_group_name  = "RG-Development"
    storage_account_name = "tfstatesstorage0001"
    container_name       = "personalblog"
    key                  = "personalblog.tfstate"
  }
}

provider "azurerm" {
  features {
    key_vault {
      purge_soft_delete_on_destroy    = true
      recover_soft_deleted_key_vaults = true
    }
  }
}
