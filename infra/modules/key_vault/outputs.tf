output "kv_id" {
  value = azurerm_key_vault.kv.id
}

output "kv_authdbpassword_secret_id" {
  value = azurerm_key_vault_secret.AuthDbPasswordSecret.id
}

output "kv_blogdbpassword_secret_id" {
  value = azurerm_key_vault_secret.BlogDbPasswordSecret.id
}