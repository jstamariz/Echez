import React from "react";
import { Link, useNavigate } from "react-router-dom";

function NavBar() {
	const navigate = useNavigate();

	const handleLogout = () => {
		localStorage.removeItem("token");
		navigate("/login");
	};

	return (
		<nav
			style={{
				display: "flex",
				flexDirection: "row",
				width: "100%",
				alignItems: "center",
				justifyContent: "space-between",
			}}
		>
			<span style={{ padding: "10px" }}>
				<Link style={{ paddingInline: "20px" }} to="/">
					Products
				</Link>
				<Link style={{ paddingInline: "20px" }} to="/create-product">
					Create Product
				</Link>
			</span>
			<button
				style={{ alignSelf: "flex-end", width: "100px", marginInline: "20px" }}
				onClick={handleLogout}
			>
				Logout
			</button>
		</nav>
	);
}

export default NavBar;
