use axum::Router;
use dotenv::dotenv;
use hyper::Method;
use log::info;
use std::env;
use tower_http::cors::CorsLayer;
use tower_http::cors::Any;

use crate::controllers::auth_controller;
use crate::controllers::service_controller;

mod controllers;
mod contracts;

#[tokio::main]
async fn main() {
    dotenv().ok();
    env_logger::init();

    info!("Server starting...");

    let app_environment = env::var("APP_ENVIRONMENT").unwrap_or("development".to_string());
    let app_host = env::var("APP_HOST").unwrap_or("0.0.0.0".to_string());
    let app_port = env::var("APP_PORT").unwrap_or("80".to_string());

    info!("Server configured to accept connections on host {}...", app_host);
    info!("Server configured to listen connections on port {}...", app_port);
    info!("Server configured to run in {} environment...", app_environment);

    let cors = CorsLayer::new()
        .allow_methods([Method::GET, Method::POST])
        .allow_origin(Any);

    let routes = Router::new()
        .merge(service_controller::router())
        .merge(auth_controller::router())
        .layer(cors);
    
    let bind_address = app_host + ":" + &app_port;
    axum::Server::bind(&bind_address.parse().unwrap())
        .serve(routes.into_make_service())
        .await
        .unwrap();

    info!("Server stopped.");
}