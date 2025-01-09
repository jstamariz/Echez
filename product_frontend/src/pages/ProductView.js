import React, { useState, useEffect } from 'react';
import axiosInstance from '../api/axiosInstance';
import { useParams } from 'react-router-dom';

function ProductView() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);

  useEffect(() => {
    axiosInstance.get(`/api/products/${id}`).then((response) => setProduct(response.data));
  }, [id]);

  if (!product) return <p>Loading...</p>;

  return (
    <div className="product-view-container">
      <h2>{product.name.value}</h2>
      <img src={product.image} alt={product.name.value} />
      <p>{product.description.value}</p>
      <p>${product.price.value}</p>
    </div>
  );
}

export default ProductView;
