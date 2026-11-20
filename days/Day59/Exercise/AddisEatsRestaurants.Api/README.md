
Method-And-Path							Purpose								Success		Failures

GET /api/v1/MenuItem					List, filtered and paged			200			400
GET /api/v1/MenuItem/{id}				One menu							200			400

GET /api/v1/restaurants					List, filtered and paged			200			400
GET /api/v1/restaurants/{id}			One restaurant						200			404
GET /api/v1/Restaurant/Active			List, filtered with aactive			200			404
GET /api/v1/restaurants/{id}/menu		That restaurant's menu				200			404
GET /api/v1/restaurants/{id}/menu/{id}	That restaurant's menu filterd		200			404

POST /api/v1/orders						Place an order						201			404,409
GET /api/v1/orders/{id}					Read one order						200			404