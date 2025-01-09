import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Products from "./pages/Products";
import ProductView from "./pages/ProductView";
import CreateProduct from "./pages/CreateProduct";
import UpdateProduct from "./pages/UpdateProduct";
import ProtectedRoute from "./components/ProtectedRoute";
import NavBar from "./components/NavBar";

function App() {
	return (
		<Router>
			<NavBar />
			<Routes>
				<Route path="/login" element={<Login />} />
				<Route path="/register" element={<Register />} />
				<Route
					path="/"
					element={
						<ProtectedRoute>
							<Products />
						</ProtectedRoute>
					}
				/>
				<Route
					path="/product/:id"
					element={
						<ProtectedRoute>
							<ProductView />
						</ProtectedRoute>
					}
				/>
				<Route
					path="/create-product"
					element={
						<ProtectedRoute>
							<CreateProduct />
						</ProtectedRoute>
					}
				/>
				<Route
					path="/update-product/:id"
					element={
						<ProtectedRoute>
							<UpdateProduct />
						</ProtectedRoute>
					}
				/>
			</Routes>
		</Router>
	);
}

export default App;
