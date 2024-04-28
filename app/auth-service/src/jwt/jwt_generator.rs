use std::time::{Duration, SystemTime, UNIX_EPOCH};

use jsonwebtoken::{errors::Error, DecodingKey, EncodingKey, Header};
use serde::{Deserialize, Serialize};

use crate::persistance::user::User;

#[derive(Deserialize, Serialize, Debug)]
pub struct Claims {
    pub sub: String,
    pub role: String,
    pub exp: u64,
}

pub struct Keys {
    pub encoding_key : EncodingKey,
    pub decoding_key : DecodingKey
}

impl Keys {
    pub fn new(encoding_key: &[u8], decoding_key: &[u8]) -> Self {
        Self { 
            encoding_key: EncodingKey::from_secret(encoding_key), 
            decoding_key: DecodingKey::from_secret(decoding_key)
        }
    }
}

pub struct JwtGenerator{
    pub keys : Keys
}
impl JwtGenerator{
    pub fn new(keys : Keys) -> Self {
        Self { keys }
    }
    pub fn produce_token(&self, user: &User) -> Result<String,Error>{
        let exp_time = JwtGenerator::get_timestamp(60*60*8);
        let claims = Claims{
            sub: user.uid.to_owned(),
            role:"user".to_string(),
            exp: exp_time
        };
        let token = jsonwebtoken::encode(&Header::default(),&claims,&self.keys.encoding_key)?;

        Ok(token)
    }

    fn get_timestamp(diff_in_secs:u64) -> u64 {
        let now = SystemTime::now();
        let since_the_epoch = now.duration_since(UNIX_EPOCH).expect("Error resolving time");
        let future_time = since_the_epoch + Duration::from_secs(diff_in_secs);
        return future_time.as_secs();
    }
}
