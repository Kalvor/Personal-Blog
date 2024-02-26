variable "location" {
  type        = string
}

variable "rg_name" {
  type        = string
}

variable "nsg_name" {
  type        = string
}

variable "vnet_name" {
  type        = string
}

variable "address_space" {
  type        = string
}

variable "k8s_subnet_name" {
  type        = string
}

variable "k8s_subnet_address" {
  type        = string
}

variable "app_gateway_subnet_name" {
  type        = string
}

variable "app_gateway_subnet_address" {
  type        = string
}
