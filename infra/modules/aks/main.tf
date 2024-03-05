resource "random_string" "prefix" {
  length  = 12
  special = false
  upper   = false
}

resource "azurerm_container_registry" "acr" {
  name                = "${var.acr_name_prefix}${random_string.prefix.result}"
  resource_group_name = var.rg_name
  location            = var.location
  sku                 = "Basic"
  admin_enabled       = false
}

resource "azurerm_kubernetes_cluster" "aks" {
  name                             = var.aks_name
  location                         = var.location
  resource_group_name              = var.rg_name
  dns_prefix                       = var.aks_dns_prefix
  node_resource_group              = "${var.rg_name}-AKS-Backend"
  http_application_routing_enabled = true
  
  default_node_pool {
    name             = "default"
    node_count       = 1
    vm_size          = "Standard_D2_v2"
    vnet_subnet_id   = var.subnet_id
  }

  identity {
    type = "SystemAssigned"
  }

  ingress_application_gateway {
    gateway_id = var.app_gateway_id
  }

  network_profile {
    network_plugin = "azure"
  }
}

resource "azurerm_role_assignment" "aks_to_acr" {
  scope                = azurerm_container_registry.acr.id
  principal_id         = azurerm_kubernetes_cluster.aks.kubelet_identity[0].object_id
  role_definition_name = "AcrPull"
}

resource "azurerm_role_assignment" "aks_to_appgwp_subnet" {
  scope                = var.app_gateway_subnet_id
  principal_id         = azurerm_kubernetes_cluster.aks.ingress_application_gateway[0].ingress_application_gateway_identity[0].object_id
  role_definition_name = "Network Contributor"
}

resource "azurerm_role_assignment" "aks_to_appgw_rg" {
  scope                = var.app_gateway_id
  principal_id         = azurerm_kubernetes_cluster.aks.ingress_application_gateway[0].ingress_application_gateway_identity[0].object_id
  role_definition_name = "Contributor"
}

resource "azurerm_role_assignment" "aks_to_appgwp" {
  scope                = var.app_gateway_id
  principal_id         = azurerm_kubernetes_cluster.aks.ingress_application_gateway[0].ingress_application_gateway_identity[0].object_id
  role_definition_name = "Reader"
}
 