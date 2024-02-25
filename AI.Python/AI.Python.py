
import pandas as pd

from sklearn.cluster import KMeans

import matplotlib.pyplot as plt

from io import BytesIO

 

def run_kmeans(csv_path, num_clusters, feature_columns):

    # Read CSV file into a DataFrame

    with open(csv_path, 'rb') as f:

        data = pd.read_csv(BytesIO(f.read().decode('windows-1250').encode('UTF-8')), sep=';', header=0)

 

    # Extract the specified feature columns

    features = data[feature_columns]

 

    # Initialize KMeans model

    kmeans = KMeans(n_clusters=num_clusters)

 

    # Fit the model to the data

    kmeans.fit(features)

 

    # Add the cluster labels to the original DataFrame

    data['cluster'] = kmeans.labels_

 

    # Plot the clusters

    plt.scatter(features.iloc[:, 0], features.iloc[:, 1], c=kmeans.labels_, cmap='viridis', marker='o')

    plt.scatter(kmeans.cluster_centers_[:, 0], kmeans.cluster_centers_[:, 1], c='red', marker='X', s=200, label='Centroids')

    plt.title('K-Means Clustering')

    plt.xlabel(feature_columns[5])

    plt.ylabel(feature_columns[7])

    plt.legend()

    plt.show()

 

    # Convert cluster centers to DataFrame and then to JSON

    cluster_centers_df = pd.DataFrame(kmeans.cluster_centers_, columns=feature_columns)

    cluster_centers_json = cluster_centers_df.to_json(orient='split')

 

    # Print the results or return them as needed

    # print("Cluster Centers:")

    print(cluster_centers_json)

    # print("Cluster Assignments:")

    # print(data[feature_columns + ['cluster']])

 

# Example usage:

csv_file_path = 'C:\\Users\\...\\IpTestSubset.csv'

num_clusters = 8

selected_features = ['feature1', 'feature2', 'feature5', 'feature6', 'feature8', 'feature11', 'feature13', 'feature9']

run_kmeans(csv_file_path, num_clusters, selected_features)