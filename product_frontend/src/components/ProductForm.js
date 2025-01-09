export default function ProductForm({
	title,
	handleSubmit,
	formValues: { name, price, description, image },
	formFunctions: { setName, setPrice, setDescription, setImage },
}) {
	return (
		<form onSubmit={handleSubmit}>
			<h2>{title}</h2>
			<input
				type="text"
				placeholder="Name"
				value={name}
				onChange={(e) => setName(e.target.value)}
				required
			/>
			<input
				type="number"
				placeholder="Price"
				value={price}
				onChange={(e) => setPrice(e.target.value)}
				required
			/>
			<textarea
				placeholder="Description"
				value={description}
				onChange={(e) => setDescription(e.target.value)}
				required
			></textarea>
			<input
				type="url"
				placeholder="Image URL"
				value={image}
				onChange={(e) => setImage(e.target.value)}
				required
			/>
			<button type="submit">{title}!</button>
		</form>
	);
}
