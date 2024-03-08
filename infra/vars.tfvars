resource_group_location = "North Europe"
resource_group_name     = "RG-Personal-Blog"

vnet_address_space         = "10.10.0.0/16"
k8s_subnet_name            = "personal-blog-k8s"
k8s_subnet_address         = "10.10.1.0/24"
app_gateway_subnet_name    = "personal-blog-appgateway"
app_gateway_subnet_address = "10.10.2.0/24"
vnet_name                  = "vnet-personal-blog"
vnet_nsg_name              = "nsg-personal-blog"

acr_name_prefix = "acrpersonalblog"
aks_name        = "aks-personal-blog"
aks_dns_prefix  = "personal-blog-k8s"

app_gateway_name           = "app-gateway-personal-blog"
app_gateway_public_ip_name = "pub-ip-personal-blog"

kv_name = "Parsonl-Blog-KV"

sqlserver_name = "sql-server-personal-blog"
authdb_name = "SQL-Db-Auth"
blogdb_name = "SQL-Db-Auth"