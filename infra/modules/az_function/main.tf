resource "azurerm_storage_account" "sa" {
  name                     = var.sa_name
  resource_group_name      = var.rg_name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_service_plan" "app_plan" {
  name                = var.app_plan_name
  location            = var.location
  resource_group_name = var.rg_name
  os_type             = "Linux"
  sku_name            = "B1"
}

resource "azurerm_linux_function_app" "az_func" {
  name                       = var.name
  location                   = var.location
  resource_group_name        = var.rg_name
  service_plan_id            = azurerm_service_plan.app_plan.id
  storage_account_name       = azurerm_storage_account.sa.name
  storage_account_access_key = azurerm_storage_account.sa.primary_access_key
  site_config { }
}