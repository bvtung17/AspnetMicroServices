# AspnetMicroservices

docker build -t asp_microservices_basket_api:0.1 -f src/Services/Basket/Basket.API/Dockerfile src

docker build -t asp_microservices_catalog_api:0.1 -f src/Services/Catalog/Catalog.API/Dockerfile src

docker build -t asp_microservices_discount_api:0.1 -f src/Services/Discount/Discount.API/Dockerfile src

docker build -t asp_microservices_ordering_api:0.1 -f src/Services/Ordering/Ordering.API/Dockerfile src