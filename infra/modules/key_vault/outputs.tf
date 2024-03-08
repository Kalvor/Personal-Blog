output "kv_id" {
  value = azurerm_key_vault.kv.id
}

output "kv_sqlserverpassword" {
  value = random_password.SqlServerPassword.result
}