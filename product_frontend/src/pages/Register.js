import React, { useState } from "react";
import axiosInstance from "../api/axiosInstance";
import { Link, Navigate } from "react-router-dom";

function Register() {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");

	const handleSubmit = async (e) => {
		e.preventDefault();
		try {
			const response = await axiosInstance.post("/api/users/register", {
				email: username,
				password,
			});
			if (response.status === 200) Navigate("/login");
		} catch (error) {
			alert("Registration failed");
		}
	};

	return (
		<div className="form-container">
			<form onSubmit={handleSubmit}>
				<h2>Register</h2>
				<input
					type="text"
					placeholder="Email"
					value={username}
					onChange={(e) => setUsername(e.target.value)}
					required
				/>
				<input
					type="password"
					placeholder="Password"
					value={password}
					onChange={(e) => setPassword(e.target.value)}
					required
				/>
				<button type="submit">Register</button>
				<p>
					Already have an account? <Link to="/login">Login</Link>
				</p>
			</form>
		</div>
	);
}

export default Register;
