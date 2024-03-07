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

docker-recreate-all:
	docker build .\app\auth-service\ -t=auth-service:latest
	docker build .\app\blog-service\ -t=blog-service:latest
	docker-compose up --build --force-recreate --no-deps -d

test-all:
	echo "TODO";