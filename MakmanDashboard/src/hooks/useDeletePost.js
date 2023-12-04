import { useMutation, useQueryClient } from '@tanstack/react-query';
import { deletePost } from '../services/apiPosts';

export function useDeletePost() {
  const queryClient = useQueryClient();

  const { isLoading: isDeleting, mutate: deleteUserPost } = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ['posts'],
      });
    },
    onError: err => {
      console.log({ err });
    },
  });

  return { isDeleting, deleteUserPost };
}
