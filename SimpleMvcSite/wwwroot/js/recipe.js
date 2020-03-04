
var currentRecipe;
var ingrediantCount;

function recipeClicked(recipeName) {
    // Check to see if add new recipe was clicked, if it was zero out the feilds.
    if (recipeName === 'addRecipe') {
        document.getElementById('recipeId').innerHTML = '';
        document.getElementById('recipeNameInput').value = '';
        document.getElementById('recipeDescriptionInput').value = '';
        document.getElementById('recipeDirectionsInput').value = '';
        if (ingrediantCount !== undefined) {
            for (let step = 1; step <= ingrediantCount; step++) {
                var recipeIngredient = document.getElementById('ingredientFeild' + step);
                recipeIngredient.parentNode.removeChild(recipeIngredient);
            }
            ingrediantCount = undefined;
        }
    }

    // If we are editing the recipe we need to show the 'add' that is prefilled.
    if (recipeName === 'editRecipe')
        recipeName = 'addRecipe';

    // Get the current showing recipe and hide it if one is displayed.
    if (currentRecipe !== undefined)
        document.getElementById(currentRecipe).hidden = true;

    // Updated the current displayed recipe to what was clicked.
    currentRecipe = recipeName;

    // Display the selected recipe.
    document.getElementById(recipeName).hidden = false;
}

function deleteRecipe(recipeId) {
    // Made the remote server call to remove the recpie.
    $(function () {
        $.ajax({
            type: "POST",
            url: 'Recipe/Delete',
            dataType: "json",
            cache: false,
            async: true,
            data: { recipeToDelete: recipeId },
            success: function (serverResponse) {
                // Check to see if there were errors, if there were not then proceed with the JS logic to remoe the UI elements.
                if (!serverResponse.startsWith("There was an error")) {
                    // Get the recipe details from the main page and remove it.
                    var recipeDetails = document.getElementById(recipeId);
                    recipeDetails.parentNode.removeChild(recipeDetails);

                    // Get the recipe from the list of recipes and remove it.
                    var recipeListItem = document.getElementById('ListItem ' + recipeId);
                    recipeListItem.parentNode.removeChild(recipeListItem);

                    // If the current recipe displayed was the one removed, set the current displayed recipe accordingly.
                    if (currentRecipe === recipeId)
                        currentRecipe = undefined;
                }

                // Dispaly a message to the end user showing the results of the request.
                alert(serverResponse);
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });
}

function addIngredient() {
    // If there are no ingredients, init the counter.
    if (ingrediantCount === undefined)
        ingrediantCount = 0;

    // Increase the current recipe counter by one. Zero is reserved for the 'template' that is cloned.
    ingrediantCount += 1;

    // Get the hidden 'template' and clone it, unhide it, and set it's id accordingly.
    var ingrediantItem = document.getElementById('ingredientFeild');
    var cln = ingrediantItem.cloneNode(true);
    cln.id = 'ingredientFeild' + ingrediantCount;
    cln.hidden = false;

    // For the elements within the cloned node, we need to set their respeective ids accordingly.
    cln.getElementsByTagName('input')[0].id = 'ingredientAmountFeildInput' + ingrediantCount;
    cln.getElementsByTagName('select')[0].id = 'ingrediantInsrument' + ingrediantCount;
    cln.getElementsByTagName('input')[1].id = 'ingredientNameFeildInput' + ingrediantCount;
    cln.getElementsByTagName('button')[0].id = ingrediantCount;
    cln.getElementsByTagName('button')[0].addEventListener('click', function (event) { deleteIngredient(event.target.id); });

    // Add the cloned and updated node onto the parent, the ingrediant list.
    ingrediantItem.parentNode.appendChild(cln);
}

function deleteIngredient(ingredientToDelete) {
    // Find the ingredient that was selected to be removed and remove it from the DOM.
    var ingredient = document.getElementById('ingredientFeild' + ingredientToDelete);
    ingredient.parentNode.removeChild(ingredient);
}

function saveRecipe() {

    // Get the basic information from associated input boxes and start to build out the recipe to save.
    var recipe = {
        id: document.getElementById('recipeId').innerHTML,
        name: document.getElementById('recipeNameInput').value,
        description: document.getElementById('recipeDescriptionInput').value,
        ingredients: [],
        instructions: document.getElementById('recipeDirectionsInput').value
    };

    // We need to iterate over the ingredients and add them to the ingredient list from above.
    for (let step = 1; step <= ingrediantCount; step++) {
        // We are no guranteed the ingredient exists as it might have been removed.
        var ingredientExists = document.getElementById('ingredientFeild' + step);
        if (ingredientExists !== null) {
            // If the Ingredient exists grab the three parts of it, build the object and add it to the recipe.
            var ingredient = {
                name: document.getElementById('ingredientNameFeildInput' + step).value,
                amount: document.getElementById('ingredientAmountFeildInput' + step).value,
                instrument: document.getElementById('ingrediantInsrument' + step).value
            };
            recipe.ingredients.push(ingredient);
        }
    }

    $(function () {
        $.ajax({
            type: "POST",
            url: 'Recipe/Add',
            dataType: "json",
            cache: false,
            async: true,
            data: { recipeToAdd: recipe },
            success: function (serverResponse) {
                // Check to see if there were errors, if there were not then proceed with the JS logic to refesh the page.
                if (!serverResponse.startsWith("There was an error")) {
                    location.reload();
                }
                // Dispaly a message to the end user showing the results of the request.
                alert(serverResponse);
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });
}

function editRecipe() {
    document.getElementById('recipeId').innerHTML = currentRecipe;
    document.getElementById('recipeNameInput').value = document.getElementById('name ' + currentRecipe).innerHTML;
    document.getElementById('recipeDescriptionInput').value = document.getElementById('description ' + currentRecipe).innerHTML;
    document.getElementById('recipeDirectionsInput').value = document.getElementById('instructions ' + currentRecipe).innerHTML;
    ingrediantCount = document.getElementById('ingredientCount ' + currentRecipe).innerHTML;
    for (let step = 1; step <= ingrediantCount; step++) {

        // Get the hidden 'template' and clone it, unhide it, and set it's id accordingly.
        var ingrediantItem = document.getElementById('ingredientFeild');
        var cln = ingrediantItem.cloneNode(true);
        cln.id = 'ingredientFeild' + step;
        cln.hidden = false;

        // For the elements within the cloned node, we need to set their respective ids and values accordingly.
        cln.getElementsByTagName('input')[0].id = 'ingredientAmountFeildInput' + step;
        cln.getElementsByTagName('input')[0].value = document.getElementById('ingredientAmount ' + currentRecipe + ' ' + step).innerHTML;
        cln.getElementsByTagName('select')[0].id = 'ingrediantInsrument' + step;
        cln.getElementsByTagName('select')[0].value = document.getElementById('ingredientInstrument ' + currentRecipe + ' ' + step).innerHTML;
        cln.getElementsByTagName('input')[1].id = 'ingredientNameFeildInput' + step;
        cln.getElementsByTagName('input')[1].value = document.getElementById('ingredientName ' + currentRecipe + ' ' + step).innerHTML;
        cln.getElementsByTagName('button')[0].id = step;
        cln.getElementsByTagName('button')[0].addEventListener('click', function (event) { deleteIngredient(event.target.id); });

        // Add the cloned and updated node onto the parent, the ingrediant list.
        ingrediantItem.parentNode.appendChild(cln);
    }

    recipeClicked('editRecipe');
}