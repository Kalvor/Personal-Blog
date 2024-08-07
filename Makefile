compile-all:
	@echo. 
	@echo --- auth-service ---
	@echo. 
	cargo build --manifest-path .\app\auth-service\Cargo.toml 

	@echo. 
	@echo --- blog-service ---
	@echo. 
	dotnet build .\app\blog-service

	@echo. 
	@echo --- terraform ---	
	@echo. 
	terraform fmt -check .\infra\ 

setup-dev-env:
	docker-compose -f .\dev-env\docker-compose.yaml down -v --rmi all --remove-orphans
	docker build .\app\auth-service\ -t=auth-service:latest
	docker build .\app\newsletter-fn\ -f ".\app\newsletter-fn\src\newsletter-fn\Dockerfile" -t=newsletter-fn:latest
	docker build .\app\blog-service\ -f ".\app\blog-service\src\blog-service.RestApi\Dockerfile" -t=blog-service:latest
	docker-compose -f .\dev-env\docker-compose.yaml up --build --force-recreate --no-deps -d

destroy-dev-env:
	docker-compose -f .\dev-env\docker-compose.yaml down -v --rmi all --remove-orphans

add-migration:
	dotnet ef migrations add --project app\blog-service\src\blog-service.External --startup-project app\blog-service\src\blog-service.RestApi --output-dir Persistance\Migrations $(name)

remove-migration:
	dotnet ef migrations remove --project app\blog-service\src\blog-service.External --startup-project app\blog-service\src\blog-service.RestApi

apply-migration:
	dotnet ef database update --project app\blog-service\src\blog-service.External --startup-project app\blog-service\src\blog-service.RestApi

test-all:
	echo "TODO"