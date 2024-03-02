module "resource_group" {
  source    = "./modules/resource_group"
  location  = var.resource_group_location
  name      = var.resource_group_name
}

module "vnet" {
  depends_on                 = [module.resource_group.id]
  source                     = "./modules/vnet"
  location                   = var.resource_group_location
  rg_name                    = var.resource_group_name
  nsg_name                   = var.vnet_nsg_name
  vnet_name                  = var.vnet_name
  k8s_subnet_name            = var.k8s_subnet_name
  k8s_subnet_address         = var.k8s_subnet_address
  app_gateway_subnet_address = var.app_gateway_subnet_address
  app_gateway_subnet_name    = var.app_gateway_subnet_name
  address_space              = var.vnet_address_space
}

module "app_gateway"{
  depends_on      = [module.resource_group.id]
  source          = "./modules/app_gateway"
  name            = var.app_gateway_name
  location        = var.resource_group_location
  rg_name         = var.resource_group_name
  subnet_id       = module.vnet.app_gateway_subnet_id
  subnet_name     = var.app_gateway_name
  public_ip_name  = var.app_gateway_public_ip_name
}

module "aks" {
  depends_on      = [module.resource_group.id]
  source          = "./modules/aks"
  location        = var.resource_group_location
  rg_name         = var.resource_group_name
  rg_id           = module.resource_group.id
  acr_name_prefix = var.acr_name_prefix
  aks_name        = var.aks_name 
  aks_dns_prefix  = var.aks_dns_prefix
  subnet_id       = module.vnet.k8s_subnet_id
  app_gateway_id  = module.app_gateway.id
  app_gateway_subnet_id = module.vnet.app_gateway_subnet_id
}
