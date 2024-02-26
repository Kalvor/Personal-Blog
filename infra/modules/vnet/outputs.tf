output "k8s_subnet_id" {
  value = azurerm_virtual_network.virtual_network.subnet.*.id[0]
}

output "app_gateway_subnet_id" {
  value = azurerm_virtual_network.virtual_network.subnet.*.id[1]
}