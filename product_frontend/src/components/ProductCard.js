import React from 'react';
import { Link } from 'react-router-dom';

function ProductCard({ product }) {
  return (
    <div className="product-card">
      <h3>{product.name.value}</h3>
      <p>${product.price.value}</p>
      <img src={product.image} alt={product.name.value} />
      <p>
        <Link to={`/product/${product.id}`}>View Details</Link>
      </p>
      <p>
        <Link to={`/update-product/${product.id}`}>Edit Product</Link>
      </p>
    </div>
  );
}

export default ProductCard;
