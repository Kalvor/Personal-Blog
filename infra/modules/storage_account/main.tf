resource "azurerm_storage_account" "sa" {
  name                     = var.name
  resource_group_name      = var.rg_name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "GRS"
}

resource "azurerm_storage_container" "userphotoscontainer" {
  name                  = "userphotos"
  storage_account_name  = var.name
  container_access_type = "private"
}

resource "azurerm_storage_container" "articlefilescontainer" {
  name                  = "articlefiles"
  storage_account_name  = var.name
  container_access_type = "private"
}