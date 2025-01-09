import React, { useState } from "react";
import axiosInstance from "../api/axiosInstance";
import { Link, useNavigate } from "react-router-dom";

function Login() {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");
	const navigate = useNavigate();

	const handleSubmit = async (e) => {
		e.preventDefault();
		const response = await axiosInstance.post("/api/users/login", {
			email: username,
			password,
		});

		if (response.status > 400) {
			alert("login failed");
			return;
		}

		localStorage.setItem("token", response.data.accessToken);
		localStorage.setItem("refresh", response.data.refreshToken);
		navigate("/");
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
					Maybe you need an account <Link to="/register">Register</Link>
				</p>
			</form>
		</div>
	);
}

export default Login;
