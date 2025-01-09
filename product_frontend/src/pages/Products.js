import React, { useState, useEffect } from "react";
import axiosInstance from "../api/axiosInstance";
import ProductCard from "../components/ProductCard";

function Products() {
	const [products, setProducts] = useState([]);
	const [search, setSearch] = useState("");

	useEffect(() => {
		axiosInstance
			.get("/api/products")
			.then((response) => setProducts(response.data ?? []));
	}, []);

	const handleSearch = (e) => {
		const name = e.target.value;
		setSearch(name);

		if (name) {
			axiosInstance
				.get(`/api/products/search/${e.target.value}`)
				.then((response) => setProducts(response.data));
		} else {
			axiosInstance
				.get("/api/products")
				.then((response) => setProducts(response.data ?? []));
		}
	};

	return (
		<div className="container">
			<h2>Products</h2>
			<div className="search-bar">
				<input
					type="text"
					placeholder="Search products"
					value={search}
					onChange={handleSearch}
				/>
			</div>
			<div className="product-list">
				{products.map((product) => (
					<ProductCard key={product.id} product={product} />
				))}
			</div>
		</div>
	);
}

export default Products;
