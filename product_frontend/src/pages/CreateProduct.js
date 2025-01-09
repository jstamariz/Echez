import React, { useState } from "react";
import axiosInstance from "../api/axiosInstance";
import { useNavigate } from "react-router-dom";
import ProductForm from "../components/ProductForm";

function CreateProduct() {
	const navigate = useNavigate();
	const [name, setName] = useState("");
	const [price, setPrice] = useState("");
	const [description, setDescription] = useState("");
	const [image, setImage] = useState("");

	const handleSubmit = async (e) => {
		e.preventDefault();
		try {
			await axiosInstance.post("/api/products", {
				name,
				price: parseFloat(price),
				description,
				image,
			});
			navigate("/");
		} catch (error) {
			alert("Failed to create product");
		}
	};

	return (
		<ProductForm
			title={"Create Product"}
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

export default CreateProduct;
