use axum::response::IntoResponse;
use axum::Json;
use axum::Router;
use axum::routing::{get,post};
use hyper::StatusCode;
use log::info;

use crate::contracts::request::LoginRequest;

pub fn router() -> Router{
    Router::new()
        .route("/api/v1/service/login", post(login))
}

pub async fn login(Json(login_request): Json<LoginRequest>) -> impl IntoResponse {
    info!("UserName {}",login_request.username );
    info!("Password {}",login_request.password );

    (StatusCode::OK, Json("response"))
}