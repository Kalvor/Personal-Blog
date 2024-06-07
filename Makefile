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
	docker build .\app\auth-service\ -t=auth-service:latest
	docker build .\app\blog-service\ -f ".\app\blog-service\src\blog-service.RestApi\Dockerfile" -t=blog-service:latest
	docker-compose -f .\dev-env\docker-compose.yaml up --build --force-recreate --no-deps -d

destroy-dev-env:
	docker-compose -f .\dev-env\docker-compose.yaml down -v --rmi all --remove-orphans

test-all:
	echo "TODO";