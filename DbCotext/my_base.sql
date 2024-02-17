CREATE TABLE shops (
    id SERIAL PRIMARY KEY,
    Name VARCHAR(70),
    Description TEXT
);

CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    Mavzu VARCHAR(70) UNIQUE,
    age INT,
    shop_id INT,
    FOREIGN KEY (shop_id) REFERENCES shops(id)
);