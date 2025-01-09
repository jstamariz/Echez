import React, { useState, useEffect } from "react";
import axios from "axios";
import { useParams, useNavigate } from "react-router-dom";
import ProductForm from "../components/ProductForm";

function UpdateProduct() {
	const { id } = useParams();
	const navigate = useNavigate();
	const [name, setName] = useState("");
	const [price, setPrice] = useState("");
	const [description, setDescription] = useState("");
	const [image, setImage] = useState("");

	useEffect(() => {
		axios.get(`/api/products/${id}`).then((response) => {
			const product = response.data;
			setName(product.name.value);
			setPrice(product.price.value);
			setDescription(product.description.value);
			setImage(product.image);
		});
	}, [id]);

	const handleSubmit = async (e) => {
		e.preventDefault();
		try {
			await axios.put(`/api/products/${id}`, {
				id: parseInt(id),
				name,
				price: parseFloat(price),
				description,
				image,
			});
			alert("Product updated successfully");
			navigate("/");
		} catch (error) {
			alert("Failed to update product");
		}
	};

	return (
		<ProductForm
			title={"Update Product"}
			handleSubmit={handleSubmit}
			formFunctions={{
				setDescription,
				setImage,
				setName,
				setPrice,
			}}
			formValues={{
				description,
				image,
				name,
				price,
			}}
		/>
	);
}

export default UpdateProduct;
