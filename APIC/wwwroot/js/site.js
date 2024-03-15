function saveFavoriteImage(imageData) {
    let favorites = JSON.parse(localStorage.getItem("catFavorites")) || [];
    favorites.push(imageData);
    localStorage.setItem("catFavorites", JSON.stringify(favorites));
}

function getFavoriteImages() {
    return localStorage.getItem("catFavorites") || "[]";
}

function removeFavoriteImage(imageId) {
    let favorites = JSON.parse(localStorage.getItem("catFavorites")) || [];
    let updatedFavorites = favorites.filter(f => f._id !== imageId);
    localStorage.setItem("catFavorites", JSON.stringify(updatedFavorites));
}

function updateFavoriteImage(imageId, updatedTags) {
    let favorites = JSON.parse(localStorage.getItem("catFavorites")) || [];
    let favoriteIndex = favorites.findIndex(f => f._id === imageId);
    if (favoriteIndex !== -1) {
        favorites[favoriteIndex].tags = updatedTags;
        // Mettre à jour la date de modification avec la date et l'heure actuelles
        favorites[favoriteIndex].updatedAt = new Date().toISOString();
        localStorage.setItem("catFavorites", JSON.stringify(favorites));
    }
}