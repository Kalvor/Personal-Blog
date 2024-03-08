data "azurerm_client_config" "current" {}

resource "azurerm_key_vault" "kv" {
  name                        = var.name
  location                    = var.location
  resource_group_name         = var.rg_name
  enabled_for_disk_encryption = true
  tenant_id                   = data.azurerm_client_config.current.tenant_id
  soft_delete_retention_days  = 7
  purge_protection_enabled    = false

  sku_name = "standard"

  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

    secret_permissions = [
      "Get", "Delete", "List", "Set"
    ]
  }
}

resource "random_password" "AuthDbPassword" {
  length           = 24
  special          = true
  override_special = "!#$%&*()-_=+[]{}<>:?"
}
resource "azurerm_key_vault_secret" "AuthDbPasswordSecret" {
  name         = "AuthDbPassword"
  value        = random_password.AuthDbPassword.result
  key_vault_id = azurerm_key_vault.kv.id
}

resource "random_password" "BlogDbPassword" {
  length           = 24
  special          = true
  override_special = "!#$%&*()-_=+[]{}<>:?"
}
resource "azurerm_key_vault_secret" "BlogDbPasswordSecret" {
  name         = "BlogDbPassword"
  value        = random_password.BlogDbPassword.result
  key_vault_id = azurerm_key_vault.kv.id
}