import React, { useState, useEffect } from 'react';
import axiosInstance from '../api/axiosInstance';
import { useParams, useNavigate } from 'react-router-dom';

function ProductView() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);

  useEffect(() => {
    axiosInstance.get(`/api/products/${id}`).then((response) => setProduct(response.data));
  }, [id]);

  const handleDelete = async () => {
    try {
      await axiosInstance.delete(`/api/products/${id}`);
      navigate('/');
    } catch (error) {
      alert('Failed to delete product');
    }
  };

  if (!product) return <p>Loading...</p>;

  return (
    <div className="product-view-container">
      <h2>{product.name.value}</h2>
      <img src={product.image} alt={product.name.value} />
      <p>{product.description.value}</p>
      <p>${product.price.value}</p>
      <button onClick={handleDelete} className="delete-button">Delete Product</button>
    </div>
  );
}

export default ProductView;
