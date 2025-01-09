import React, { useState } from "react";
import axiosInstance from "../api/axiosInstance";
import { Link } from "react-router-dom";

function Login() {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");

	const handleSubmit = async (e) => {
		e.preventDefault();
		try {
			const response = await axiosInstance.post("/api/users/login", {
				username,
				password,
			});
			localStorage.setItem("token", response.data.token);
			alert("Login successful");
		} catch (error) {
			alert("Login failed");
		}
	};

	return (
		<div className="form-container">
			<form onSubmit={handleSubmit}>
				<h2>Login</h2>
				<input
					type="text"
					placeholder="Username"
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
				<button type="submit">Login</button>
				<p>
					Maybe you need an account{" "}
					<Link to="/register">Register</Link>
				</p>
			</form>
		</div>
	);
}

export default Login;
