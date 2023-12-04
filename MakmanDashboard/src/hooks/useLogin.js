import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';
import { login } from '../services/apiAuth';

export function useLogin() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  const { mutate: loginUser, isLoading } = useMutation({
    mutationFn: ({ email, password }) => login({ email, password }),
    onSuccess: user => {
      queryClient.setQueryData(['user'], user.user);
      navigate('/posts', { replace: true });
    },
    onError: err => {
      console.log('ERROR', err);
    },
  });

  return { loginUser, isLoading };
}
