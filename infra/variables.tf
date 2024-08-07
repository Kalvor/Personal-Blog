variable "resource_group_location" {
  type = string
}

variable "resource_group_name" {
  type = string
}

variable "vnet_nsg_name" {
  type = string
}

variable "vnet_name" {
  type = string
}

variable "vnet_address_space" {
  type = string
}

variable "k8s_subnet_name" {
  type = string
}

variable "k8s_subnet_address" {
  type = string
}

variable "app_gateway_subnet_name" {
  type = string
}

variable "app_gateway_subnet_address" {
  type = string
}

variable "acr_name_prefix" {
  type = string
}

variable "aks_name" {
  type = string
}

variable "aks_dns_prefix" {
  type = string
}

variable "app_gateway_name" {
  type = string
}

variable "app_gateway_public_ip_name" {
  type = string
}

variable "kv_name" {
  type = string
}

variable "sa_name" {
  type = string
}

variable "sqlserver_name" {
  type = string
}

variable "authdb_name" {
  type = string
}

variable "blogdb_name" {
  type = string
}

variable "function_app_plan_name" {
  type = string
}

variable "function_sa_name" {
  type = string
}

variable "function_name" {
  type = string
}